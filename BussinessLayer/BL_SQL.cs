using System.Collections.Generic;
using BLInterfaces;
using DataLayer;

namespace BussinessLayer
{
    public class BL_SQL:IBL
    {
        private IDL _dal;
        public BL_SQL(IDL db) {
            _dal = db;
        }
        public void UpdateSkillName(string new_name, string name, string type) {
            _dal.UpdateSkillName(new_name,name,type);
        }
        public string DeleteAllSkill(string name,string type) {
            return _dal.DeleteAllSkill(name,type);
        }
        public string GetRole(int Id) {
            return _dal.GetRole(Id);
        }
        public string ChangePass(string Login, string old_pass, string new_pass,string check_pass) {
            if (Login == "") {
                return "Введите логин";
            }
            if (new_pass!=check_pass && new_pass!="") {
                return "Подтвердите пароль";
            }
            return _dal.ChangePass(Login,old_pass,new_pass);
        }
        public string SetStatus(int Id,string text)
        {
            if (text == "") {
                return "Задайте статус";
            }
            return _dal.SetStatus(Id, text);
        }
        public string GetStatus(int Id) {
            return _dal.GetStatus(Id);
        }
        public string CreateUser(string Email,string Login,string Password) {
            if (Email == "" || Login == "" || Password == "")
            {
                return "Заполните поля";
            }
            return _dal.CreateUser(Email, Login, Password);
        }
        public string EntryAccount(string Login, string Password) {
            if (Login == "" || Password == "")
            {
                return "Заполните поля";
            }
            return _dal.EntryAccount(Login,Password);
        }
        public string UpdateLogin(int Id,string Login) {
            if (Login == "")
            {
                return "Неверные данные";
            }
            return _dal.UpdateLogin(Id,Login);
        }
        public string GetUserLogin(int Id) {
            return _dal.GetUserLogin(Id);
        }
        public List<Entites.Skills> GetSkillsUser(int Id){
            return _dal.GetSkillsUser(Id);
        }
        public List<string> GetListTypeSkills(){
            return _dal.GetListTypeSkills();
        }
        public List<Entites.Skills> GetListSkills() {
            return _dal.GetListSkills();
        }
        public void DeleteSkill(string name, string type, int Id){
            _dal.DeleteSkill(name,type,Id);
        }
        public string AddSkill(string name, string type) {
            if (name == "" || type == "")
            {
                return "Неверные данные";
            }
            return _dal.AddSkillOnType(name, type);
        }
        public void AddSkillUser(string name, string type,int Id) {
            _dal.AddSkillUser(name, type,Id);
        }
    }
}
