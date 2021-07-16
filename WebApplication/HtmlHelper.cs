
using Entites;
using Dependecy;

namespace WebApplication
{
    public class HtmlHelper
    {
        public string SetSkillName(string name, string type,int Id)
        {
            string html_code = "</br>";
            for (int i = 0; i < DependecyResolver.Instance.b.GetListTypeSkills().Count; i++)
            {
                html_code += "<h4>" + DependecyResolver.Instance.b.GetListTypeSkills()[i] + "</h4><table>";
                foreach (Skills s in DependecyResolver.Instance.b.GetListSkills())
                {
                    if (s.Type == DependecyResolver.Instance.b.GetListTypeSkills()[i])
                    {
                        int tmp = html_code.Length;
                        foreach (Skills c in DependecyResolver.Instance.b.GetSkillsUser(Id))
                        {
                            if (c.Name == s.Name && s.Type == c.Type)
                            {
                                if(name==s.Name && type == s.Type)
                                {
                                    html_code += "<tr><td class=\"Added\">Введите новое имя (Навык добавлен)<form></form><form method=\"POST\" Action=\"\"><input class=\"Del\" name=\"New_name\" value=\""+s.Name+"\"/><input class=\"Del\" name=\"Send\" type=\"submit\" value=\"Отправить!\"/><input class=\"Del\" name=\"Cancel\"  type=\"submit\" value=\"Отмена!\"/><input name=\"Name\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"NameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                                    continue;
                                }
                                html_code += "<tr><td class=\"Added\">" + s.Name + " (Навык добавлен)<form></form><form method=\"POST\" Action=\"\"><input class=\"Del\" type=\"submit\" value=\"Удалить навсегда и для всех\"/><input class=\"Del\" name=\"Edit\"  type=\"submit\" value=\"Изменить навык\"/><input name=\"DeleteName\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"DeleteNameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";

                            }
                        }
                        if (html_code.Length == tmp)
                        {
                            if (name == s.Name && type == s.Type)
                            {
                                html_code += "<tr><td>Введите новое имя<form></form><form method=\"POST\" Action=\"\"><input class=\"Add\" name=\"New_name\" value=\"" + s.Name + "\"/><input class=\"Del\" name=\"Send\" type=\"submit\" value=\"Отправить!\"/><input class=\"Del\" name=\"Cancel\"  type=\"submit\" value=\"Отмена!\"/><input name=\"Name\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"NameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                                continue;
                            }
                                html_code += "<tr><td>" + s.Name + "<form></form><form method=\"POST\" Action=\"\"><input class=\"Add\"  type=\"submit\" value=\"Удалить навсегда и для всех\"/><input class=\"Add\" name=\"Edit\"  type=\"submit\" value=\"Изменить навык\"/><input name=\"DeleteName\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"DeleteNameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";


                        }
                    }
                }
                html_code += "</table>";
            }
            return html_code;
        }
        public string EditHtmlListSkill(int Id)
        {
            string html_code = "</br>";
            for (int i = 0; i < DependecyResolver.Instance.b.GetListTypeSkills().Count; i++)
            {
                html_code += "<h4>" + DependecyResolver.Instance.b.GetListTypeSkills()[i] + "</h4><table>";
                foreach (Skills s in DependecyResolver.Instance.b.GetListSkills())
                {
                    if (s.Type == DependecyResolver.Instance.b.GetListTypeSkills()[i])
                    {
                        int tmp = html_code.Length;
                        foreach (Skills c in DependecyResolver.Instance.b.GetSkillsUser(Id))
                        {
                            if (c.Name == s.Name && s.Type == c.Type)
                            {
                                html_code += "<tr><td class=\"Added\">" + s.Name + " (Навык добавлен)<form></form><form method=\"POST\" Action=\"\"><input class=\"Del\" type=\"submit\" value=\"Удалить навсегда и для всех\"/><input class=\"Del\" name=\"Edit\"  type=\"submit\" value=\"Изменить навык\"/><input name=\"DeleteName\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"DeleteNameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                                
                            }
                        }
                        if (html_code.Length == tmp)
                        {
                            html_code += "<tr><td>" + s.Name + "<form></form><form method=\"POST\" Action=\"\"><input class=\"Add\"  type=\"submit\" value=\"Удалить навсегда и для всех\"/><input class=\"Add\" name=\"Edit\"  type=\"submit\" value=\"Изменить навык\"/><input name=\"DeleteName\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"DeleteNameType\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                            
                        }
                    }
                }
                html_code += "</table>";
            }
            return html_code;
        }
        public string HtmlListSkill(int Id)
        {
            string html_code = "</br>";
            for (int i = 0; i < DependecyResolver.Instance.b.GetListTypeSkills().Count; i++)
            {
                html_code += "<h4>" + DependecyResolver.Instance.b.GetListTypeSkills()[i] + "</h4><table>";
                foreach (Skills s in DependecyResolver.Instance.b.GetListSkills())
                {
                    if (s.Type == DependecyResolver.Instance.b.GetListTypeSkills()[i])
                    {
                        int tmp = html_code.Length;
                        foreach (Skills c in DependecyResolver.Instance.b.GetSkillsUser(Id))
                        {
                            if (c.Name == s.Name && s.Type == c.Type)
                            {
                                html_code += "<tr><td class=\"Added\">" + s.Name + " (Навык добавлен)<form></form><form method=\"POST\" Action=\"\"><input class=\"Delete\" type=\"submit\" value=\"Удалить\"/><input name=\"Del\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"Type\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                                
                            }
                        }
                        if (html_code.Length == tmp)
                        {
                            html_code += "<tr><td>" + s.Name + "<form></form><form method=\"POST\" Action=\"\"><input class=\"Add\"  type=\"submit\" value=\"Добавить\"/><input name=\"Add\" type=\"hidden\" value=\"" + s.Name + "\"/><input name=\"Type\" type=\"hidden\" value=\"" + s.Type + "\"/></form></td></tr>";
                            
                        }
                    }
                }
                html_code += "</table>";
            }
            return html_code;
        }
    }
}