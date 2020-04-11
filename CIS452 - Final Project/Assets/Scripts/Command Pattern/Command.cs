/*
* Conner Wolf
* Command.cs
* Final Project
* Command interface that contains the execute and undo commands.
*/


public interface Command 
{
    void Execute();
    void Undo();
}
