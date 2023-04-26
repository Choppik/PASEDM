using System;

namespace PASEDM.Models
{
    public class Card
    {
        public int NumberCard { get; } //Заполняю номер
        public int NameCard { get; } //Заполняю название
        public DateTime DateOfFormation { get; } //Формируется дата создания карты
        public string SecrecyStamp { get; } //Выбор секретности
        public string Summary { get; } //Краткое содержание документа
        public string Condition { get; } //Выбор состояния исполнения задачи
        public string Comment { get; } //Комментарий
        public string FilePath { get; } //Путь к файлу
        public string DocumentRegistrationNumber { get; } //Номер добавляемого документа
        public DateTime DateOfFormationDocument { get; } //Дата создания добавляемого документа
    }
}