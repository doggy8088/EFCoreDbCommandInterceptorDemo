public class Todo
{
    public int Id { get; set; }
    public string Item { get; set; }
    // 新增一個 IsDeleted 屬性
    public bool IsDeleted { get; set; }
    public string Creator { get; set; }
}