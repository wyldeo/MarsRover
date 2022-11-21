# MarsRover
A .NET Framework console app displaying the Mars Rover.

Given more time I would:

  * Tidy Program.cs and parser - parser should fail more silently
  * Make orientations a linked list (i.e N -> E -> S -> W -> N etc)
  * Add more tests - which properly check finished & lost
  * Add ToString() check to some unit tests
  * Change GridState so we don't need to query RoverStates each time
  * Allow the IState interface to be properly mocked
  * Have a "Command" class instead of enum, so that we don't need switch statements later on
  * Add more unit tests with a full end to end including command parser