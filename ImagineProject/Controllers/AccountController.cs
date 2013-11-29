using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ImagineProject.Models;
using System.Data.SqlClient;

namespace ImagineProject.Controllers
{
    // Clase que implementa la autenticación de usuarios por roles
    // de ASP.NET MVC3 Framework, utilizando .NET Framework 4.
  
    public class AccountController : Controller
    {

        /********************** LOG ON/OFF  ********************************************************************/
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "El nombre de usuario o la contraseña ingresada no es correcta.");
                    }
                }
                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch(SqlException ex)
            {
                Operacion error = new Operacion();
                error.Message = "Error relacionado con la red mientras se establecía una conexión con el servidor. "+
                                "No se encontró el servidor o éste no estaba accesible. "+
                                "Contacte al administrador del Sistema.";
                error.Action = "LogOn";
                error.Controller = "Account";
                return View("~/Views/Shared/Error.aspx",error);
            }
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        /*******************************************************************************************************/

        /********************** Usuarios ***********************************************************************/
        //
        // GET: /Account/Register
        [Authorize]   
        public ActionResult RegisterUser()
        {
            // Crea un DropDownList (List HTML) con los roles disponibles
            ViewBag.RoleName = new SelectList(Roles.GetAllRoles().ToList());
            return View();
        }

        //
        // POST: /Account/Register
        [Authorize]
        [HttpPost]// Recibo por Method POST una instancia de Usuario (RegisterUserModel) y el nombre del Rol.
        public ActionResult RegisterUser(RegisterUserModel model,string RoleName)
        {
            if (ModelState.IsValid)
            {
                if (!RoleName.Equals("") && !RoleName.Equals(String.Empty) && !RoleName.Equals(null))
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        // Si El estado es succesfull, agrego al usuario actual al rol seleccionado.
                        Roles.AddUserToRole(model.UserName, RoleName);

                        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.RoleName = new SelectList(Roles.GetAllRoles().ToList());
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "La contraseña actual es incorrecta o la contraseña nueva no es válida.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        //
        // GET: /Account/EditUser/5

        public ActionResult EditUser(string userName)
        {
            MembershipUser membershipUser = Membership.GetUser(userName);
            RegisterUserModel model = new RegisterUserModel();
            model.UserName = membershipUser.UserName;
            model.Email = membershipUser.Email;
            string [] roles = Roles.GetRolesForUser(membershipUser.UserName);
            model.RoleName = roles[0].ToString();
            ViewBag.RoleName = new SelectList(Roles.GetAllRoles().ToList()/*,model.RoleName*/);
            return View(model);
        }

        //
        // POST: /Barco/EditUser/5

        [HttpPost]
        public ActionResult EditUser(RegisterUserModel model, string RoleName)
        {
            MembershipUser membershipUser = Membership.GetUser(model.UserName);
            // Actualiza informaión del usuario. El UserName NO es editable.
            if (!model.Email.Equals("") && !model.Email.Equals(String.Empty) && !model.Email.Equals(null))
            {
                // Asigno a Permanentemente el e-mail ingresado, al usuario actual
                membershipUser.Email = model.Email;
                // Obtengo el Rol del usuario actual
                string oldRole = (Roles.GetRolesForUser(membershipUser.UserName).ToArray<String>())[0];

                if (!RoleName.Equals(String.Empty) && !RoleName.Equals("") && !RoleName.Equals(null))
                {
                    if (this.UpdateRoleForUser(membershipUser.UserName, oldRole, RoleName))
                    {
                        Membership.UpdateUser(membershipUser);
                        return RedirectToAction("ListUsers");
                    }
                    else 
                    {
                        ModelState.AddModelError("", "Ha ocurrido un error");
                    }
                }                
            }
            ViewBag.RoleName = new SelectList(Roles.GetAllRoles().ToList());
            return View(model);
        }
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        public Boolean UpdateRoleForUser(string UserName, string OldRoleName, string NewRoleName)
        {
            bool resultado = false;
            try 
            {
                Roles.RemoveUserFromRole(UserName, OldRoleName);
                Roles.AddUserToRole(UserName, NewRoleName);
                resultado = true;
            }
            catch 
            {
                resultado = false;
            }
            return resultado;
        }
        //
        // GET: /Account/DeleteUser

        public ActionResult DeleteUser(string userName)
        {
            MembershipUser membershipUser = Membership.GetUser(userName);
            RegisterUserModel model = new RegisterUserModel();
            model.UserName = membershipUser.UserName;
            model.Email = membershipUser.Email;
            string [] roles = Roles.GetRolesForUser(membershipUser.UserName);
            model.RoleName = roles[0].ToString();
            ViewBag.RoleName = new SelectList(Roles.GetAllRoles().ToList()/*,model.RoleName*/);
            return View(model);
        }

        //
        // POST: /Account/DeleteUser

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUserConfirmed(string userName)
        {
            bool deleted = Membership.DeleteUser(userName);
            if (!deleted)
            {
                ModelState.AddModelError("", "El usuario no se puede eliminar.");
            }
            return RedirectToAction("ListUsers");
        }

        public ViewResult ListUsers()
        {
            var users = Membership.GetAllUsers();
            return View(users);
        }

        /*******************************************************************************************************/

        /*******************  Roles  ***************************************************************************/
        //
        // GET: /Roles/RegisterRole

        [Authorize]
        public ActionResult RegisterRole()
        {
            return View();
        }

        //
        // POST: /Account/RegisterRole

        [Authorize]
        [HttpPost]
        public ActionResult RegisterRole(RegisterRoleModel model)
        {

            if (!Roles.RoleExists(model.RoleName))
            {
                Roles.CreateRole(model.RoleName);
            }
            else 
            {
                ModelState.AddModelError("","El rol que intenta crear ya existe.");
            }
            return View(model);
            //return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/DetailsRole/

        public ActionResult DetailsRole(string RoleName)
        {
            RegisterRoleModel model = new RegisterRoleModel();
            String[] usuarios;
            if (Roles.RoleExists(RoleName))
            {
                model.RoleName = RoleName;
                usuarios = Roles.GetUsersInRole(RoleName);
                //Roles.AddUsersToRole(usuarios, model.RoleName);
                ViewBag.usuarios = usuarios;
            }
            else
            {
                return RedirectToAction("ListRoles");
            }
            return View(model);
        }

        //
        // GET: /Account/EditRole/

        public ActionResult EditRole(string RoleName)
        {
            RegisterRoleModel model = new RegisterRoleModel();
            String[] usuarios;
            if (Roles.RoleExists(RoleName))
            {
                model.RoleName = RoleName;
                usuarios = Roles.GetUsersInRole(RoleName);
                //Roles.AddUsersToRole(usuarios, model.RoleName);
                ViewBag.usuarios = usuarios;
            }
            else
            {
                return RedirectToAction("ListRoles");
            }
            return View(model);
        }

        //
        // GET: /Account/DeleteRole/
        public ActionResult DeleteRole(string RoleName)
        {
            RegisterRoleModel model = new RegisterRoleModel();
            String[] usuarios;
            if (Roles.RoleExists(RoleName) && (!RoleName.Equals("") && !RoleName.Equals(String.Empty) && !RoleName.Equals(null)))
            {
                model.RoleName = RoleName;
                usuarios = Roles.GetUsersInRole(RoleName);
                ViewBag.usuarios = usuarios;
            }
            else
            {
                return RedirectToAction("ListRoles");
            }
            return View(model);
        }

        //
        // POST: /Account/DeleteRole

        [HttpPost, ActionName("DeleteRole")]
        public ActionResult DeleteRoleConfirmed(string RoleName)
        {
            if (Roles.RoleExists(RoleName) && (!RoleName.Equals("") && !RoleName.Equals(String.Empty) && !RoleName.Equals(null)))
            {
                String[] users = Roles.GetUsersInRole(RoleName.Trim());
                if (users.Length == 0)
                {
                    Roles.DeleteRole(RoleName);
                }
                if (users.Length > 0) 
                {
                    ModelState.AddModelError("", "El Rol " + RoleName + " no se puede eliminar porque tiene ususarios asociados.");
                    System.Threading.Thread.Sleep(5000);
                }
            }
            return RedirectToAction("ListRoles");
        }

        public ViewResult ListRoles()
        {            
            List<RegisterRoleModel> lista = new List<RegisterRoleModel>();
            foreach (string rol in Roles.GetAllRoles()) 
            {
                RegisterRoleModel model = new RegisterRoleModel();
                model.RoleName = rol;
                lista.Add(model);
            }
            return View(lista);
        }
        /*******************************************************************************************************/

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Por favor, introduzca un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
