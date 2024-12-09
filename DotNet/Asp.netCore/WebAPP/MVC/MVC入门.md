## Controller控制器

### 设置控制器路由
控制器中的Public方法默认是路由的，可以通过Route特性来设置路由

在Program.cs文件中
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //?代表可选
```

在控制器文件中
```csharp
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "value1", "value2" };
    }
}
```

### 返回视图 Index方法
 如果未指定视图文件名称，则返回默认视图。 默认视图与操作方法的名称相同，在本例中为 Index。 使用视图模板 /Views/HelloWorld/Index.cshtml。
```csharp
public IActionResult Index()
{
    return View();
}
```

## View视图

### 菜单布局
菜单布局在 Views/Shared/_Layout.cshtml 文件中实现。

### 数据传递
在控制器中使用ViewData字典传递数据
```csharp
public IActionResult Index()
{
    ViewData["Message"] = "Hello World!";
    return View();
}
```