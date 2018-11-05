using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pim8.Models
{
    public class Task
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string fieldName { get; set; }
        [Display(Name = "Começo da Tarefa")]
        public DateTime dateTimeStart { get; set; }
        [Display(Name = "Fim da Tarefa")]
        public DateTime dateTimeEnd { get; set; }
        [Display(Name = "Descrição da Tarefa")]
        public string description { get; set; }
    }
}