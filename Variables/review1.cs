public bool IsShopOpen(string day)
{
    if (string.IsNullOrEmpty(day))
    {
        return false;
    }

    var aListOfOpenedDays = new List<string> { "friday", "saturday", "sunday" };
    return aListOfOpenedDays.Contains(day.ToLower());
}
