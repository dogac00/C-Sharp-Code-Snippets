
private string _password;

private string Password
{
    get
    {
        return _password ?? (_password = CallExpensiveOperation());
    }
}
