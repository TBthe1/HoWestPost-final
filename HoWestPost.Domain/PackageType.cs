namespace HoWestPost.Domain
{
    public enum PackageType
    {
        //Use ints because enums (doubles ands floats won't compile)
        Mini,
        Standaard,
        Maxi,
        priority,
        regular
    }
}