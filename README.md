# Bad code


Also please clean up your based ah string encoding in the loader, well eh i cleaned it up for you :D


```

static void Main(string[] args)
{
  Console.WriteLine(FuCk("FUckfuCkFuCkFuCkFUcKFUCkFuCkFuCkFUcKFUCkFuCkFuCkFUcKFuCkFuCkFuCkFUcKFucKFuCkFuCkFucKfuckFuCkFuCkFuckfUcKFuCkFuCkFuckfUcKFuCkFuCkFUckFUcKFuCkFuCkFUckfuCKFuCkFuCkFUcKFUCkFuCkFuCkFUckfuCkFuCkFuCkFUcKFUCKFuCkFuCkFUckFuckFuCkFuCkFuckfUckFuCkFuCkFUckFucKFuCkFuCkFUckfUcKFuCkFuCkFUckfUCKFuCkFuCkFuckfUcKFuCkFuCkFUCkFUCKFuCkFuCkFUckFUCkFuCkFuCkFUckFUCKFuCkFuCkFUckfUckFuCkFuCkFUCkFUckFuCkFuCkFUckFuCKFuCkFuCkFUckfuCKFuCkFuCkFUckfUCkFuCkFuCkFUcKFucKFuCkFuCkFuckfUcKFuCkFuCkFUCKFucKFuCkFuCkFUcKFUCkFuCkFuCkFUckfUcKFuCkFuCkFUcKFuckFuCkFuCkFUckFuCKFuCkFuCkFUckFUcKFuCkFuCkFUckFUCKFuCkFuCkFUCkFUckFuCkFuCkFUckfUcKFuCkFuCkFUcKFuckFuCkFuCkFUCKFucKFuCkFuCkFUcKFUCkFuCkFuCkFUcKFUCKFuCkFuCkFUckFUckFuCkFuCkFUckFUckFuCkFuCkFuckfUcKFuCkFuCkFUcKFuckFuCkFuCkFUckFuCKFuCkFuCkFUcKFUcKFuCkFuCkFuckfUcKFuCkFuCkFUckfUCKFuCkFuCkFUckFuCKFuCkFuCkFUckfuCKFuCkFuCkFUckfUckFuCkFuCkFuckfUcKFuCkFuCkFUCkfuCkFuCkFuCkFUckFUCKFuCkFuCkFUckfUCkFuCkFuCkFUckfuCKFuCkFuCkFUcKfuCkFuCkFuCkFUCkfUCkFuCkFuCkFUckfuCKFuCkFuCkFUcKFUCkFuCkFuCkFUckFUCKFuCkFuCkFuckfUckFuCkFuCkFUckFUCkFuCkFuCkFUckfUCkFuCkFuCkFUckfUCkFuCkFuCk"));
  Console.ReadKey();
}

public static string FuCk(string _)  {
  var str = new StringBuilder();
  foreach (var (st, dat) in _.Select((cha, datt) => (cha, datt)))
     str.Append((dat % 2 == 0) ^ char.IsUpper(st) ? '1' : '0');

  return Encoding.Unicode.GetString(Enumerable.Range(0, str.Length / 8).Select(meow => Convert.ToByte(str.ToString().Substring(meow * 8, 8), 2)).ToArray());
}
```
