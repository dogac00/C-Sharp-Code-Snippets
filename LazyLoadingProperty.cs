
private string _password;

private string Password
{
    get
    {
        if (_password == null)
        {
            _password = _password ?? (_password = CallExpensiveOperation());
        }

        return _password;
    }
}
