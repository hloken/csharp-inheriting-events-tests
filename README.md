# csharp-inheriting-events-tests

Code thats tests different permuations of inheriting Event-implementations from base-class. This is very relevant for view-models that inherit from base-classes that implement PropertyChanged event.

1. Test-cases for base-class with public event (no other modifiers)
  a. Derived class defines same event => result is 2 different events with separate subscriber lists, produces compiler warning
  b. Derived class defines same event with *new* keyword => result is 2 different events with separate subscriber lists, no compiler warning
2. Test-cases for base-class with *virtual* public event:
  a. Derived class defines same event => result is 2 different events with separate subscriber lists, produces compiler warning
  b. Derived class defines same event with *new* keyword => result is 2 different events with separate subscriber lists, no compiler warning
  c. Derived class defines same event with *override* keyword => result is 1 single event with 1 subscriber list, no compiler warning
