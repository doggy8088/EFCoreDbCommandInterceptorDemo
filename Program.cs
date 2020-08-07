using System;
using efdemo1.Models;

namespace efdemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TodoContext())
            {
                db.Todos.Add(new Todo() {
                    Item = "Item 1"
                });

                db.SaveChanges();
            }

            using (var db = new TodoContext())
            {
                Console.WriteLine("查詢新增後的所有資料");
                foreach (var item in db.Todos)
                {
                    Console.WriteLine(item.Id + " " + item.Item);
                }
            }

            using (var db = new TodoContext())
            {
                foreach (var item in db.Todos)
                {
                    item.Item += "!";
                }

                db.SaveChanges();
            }

            using (var db = new TodoContext())
            {
                Console.WriteLine("查詢更新後的所有資料");
                foreach (var item in db.Todos)
                {
                    Console.WriteLine(item.Id + " " + item.Item);
                }
            }

            using (var db = new TodoContext())
            {
                var item = db.Todos.Find(1);
                if (item != null)
                {
                    db.Todos.Remove(item);
                    db.SaveChanges();
                }
            }

            using (var db = new TodoContext())
            {
                Console.WriteLine("查詢刪除編號 1 資料後的所有資料");
                foreach (var item in db.Todos)
                {
                    Console.WriteLine(item.Id + " " + item.Item);
                }
            }
        }
    }
}
