public void CreateFile(string name, bool temp = false)
{ 
    // Check whether directory exists or not 
    // if not then create a directory and Combine the File Name then make call to Touch method
    
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }

    Touch(name);
}