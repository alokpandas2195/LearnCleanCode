List<string> listOfCities = new List<string> { "Austin", "New York", "San Francisco" };

foreach (string aCity in listOfCities)
{
    DoStuff();
    DoSomeOtherStuff();
    Dispatch(aCity);
}