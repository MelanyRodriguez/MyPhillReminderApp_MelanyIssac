using MyPhillReminderApp_MelanyIssac.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPhillReminderApp_MelanyIssac.ViewModels
{
    public class UserViewModel: BaseViewModel

    {
        //el vm funciona como puente entre el modelo y la vista en sentido teorico
        //el vm "siente" los cambios de la vista
        
        public User MyUser { get; set; }
        public UserRole MyUserRole { get; set; }
        public UserDTO MyUserDTO { get; set; }
        public UserViewModel() 
        { 
          MyUser = new User();
         MyUserRole = new UserRole();
         MyUserDTO = new UserDTO();
        }

        //Funciones 

        //Funcion que carga los datos del objeto de usuario global
        public async Task<UserDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();
                userDTO = await MyUserDTO.GetUserInfo(pEmail);
                if (userDTO == null) return null;
                return userDTO;
               
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }

        //Funcion para validar el ingreso del usuario al Login
        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            //debemos poder controlar que no se ejecute la operacion mas de una vez 
            //en este caso hau una funcionalidad para eso en BaseViewModel que fue 
            //heredada al definir esta clase

            //Control de bloqueo de funcionalidad
            if (IsBusy) return false;
           IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
                throw;

            }
            finally { IsBusy = false; }

        }


        //carga la lista de roles
        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>(); 
                    roles= await MyUserRole.GetAllUserRoleAsync();
                if (roles == null)
                {
                    return null;
                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //funcion de creacion de  usuario nuevo
        public async Task<bool> AddUserAsync(string pEmail, 
                                             string pPassword, 
                                             string pName,
                                             string pBackUpEmail,
                                             string pAddress,
                                             string pPhoneNumber,
                                             int pUserRoleId)
        {
          if (IsBusy) return false;
          IsBusy = true;
            try
            {
                MyUser = new User(); 
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;
                MyUser.Name = pName;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.Address = pAddress;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.UserRoleId=pUserRoleId;
                bool R = await MyUser.AddUserAsnc();
                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally { IsBusy = false; }

        }

   public async Task<bool> UpDateUser(UserDTO pUser)

        {

            if (IsBusy) return false;

            IsBusy = true;

            try

            {

                MyUserDTO = pUser;

                bool R = await MyUserDTO.UPdateUserAsync();





                return R;

            }

            catch (Exception)

            {

                return false;

                throw;

            }

            finally { IsBusy = false; }

        }



    }
}
