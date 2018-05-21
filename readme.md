[21052018]
- the purpose of this project is to gain more knowledge in C#
- on this initial commit, we are done until the 3rd set, classes and obj
- note how the author encouraged thinking what the responsibility of classes are. 
- GradeBook needs to take note of statistics, but that is a whole thing in itself, that is why creating a new class for that is better.
- GradeBook also needs to know that members of GradeStatistics are initialized, it can do it but the author thought of using the constructor of the GradeStatistics class to initialize the members. Check it out.
- another thing to note of is that the object does not contain the actual implememtation, speaking of that, the object of a class only contains a pointer to a memory location. That is why the code "GradeBook book2 = book;" both book2 and book had the same members. book2 copied the memory address book was referring to.