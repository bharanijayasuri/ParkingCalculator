# ParkingCalculator

### Short stay car park test values and results

- 2017-09-07 16:50:00 To 2017-09-07 18:00:00 (£1.28)
- 2017-09-07 16:50:00 To 2017-09-09 19:15:00 (£12.28)
- 2019-11-03 07:00:00 To 2019-11-05 11:15:00 (£14.57)

### Long stay car park test values and results

- 2017-09-07 19:50:00 To 2017-09-09 05:20:00 (£22.50)
- 2020-05-17 12:50:00 To 2020-05-17 12:51:00 (£7.50)
- 2020-10-07 19:25:00 To 2020-10-17 12:51:00 (£82.50)


The entire project is done on .Net Core 3.1 as a simple console application.

I have used the Options pattern to capture calculation settings and used basic Factory pattern for loose coupling and dynamic object creation. 

I have tried to follow the SOLID principles and best practices to the best of my knowledge.

I have used simple MSUnit tests for the exceptions bit.
