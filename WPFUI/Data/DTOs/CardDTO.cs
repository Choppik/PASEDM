using System;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class CardDTO
    {
        [Key]
        public int ID {  get; set; }
        public int NumberCard { get; set; } //Заполняю номер!
        public int NameCard { get; set; } //Заполняю название!
        public DateTime DateOfFormation { get; set; } //Формируется дата создания карты!
        public string SecrecyStamp { get; set; } //Выбор секретности!
        public string Summary { get; set; } //Краткое содержание документа!
        public string Comment { get; set; } //Комментарий
        public int? DocumentID { get; set; } //Документ
        public DocumentDTO Document { get; set; }
        public int? DocumentTypesID { get; set; } //Вид документа!
        public DocumentTypesDTO TypeDocument { get; set; }
        public int? TaskID { get; set; } //Выбор задачи!
        public TaskDTO Task { get; set; }
        public int? CaseID { get; set; } //Выбор дела!
        public CaseDTO Case { get; set; }
        public int? UserID { get; set; }//Кто формирует карту
        public UserDTO User { get; set; }
        public int? EmployeeID { get; set; } //Выбор кто исполняет задачу!
        public EmployeeDTO Employee { get; set; }
        public int? RecipientID { get; set; } //Получатель, другой пользователь
        public RecipientDTO Recipient { get; set; }
    }
}