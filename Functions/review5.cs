
// instead of using reflection make use of interface to use polymorphism
public void TravelToTexas(object vehicle)
{
    Location aLocation = new Location("texas");
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(aLocation);
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(aLocation);
    }
}