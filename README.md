TimesheetReminder
=================

Status:

- In progress

Used technologies:

- Windows service
- Mail sending and composing
- Threads

Story:

In my company some scatterbrained software developers permanently forget to complete timesheet. 
All of us know how important it is. There's no better way to focus developer's brain on some task 
than combine it with female beauty. Once upon a time great tradition was born, tradition of sending
photos of chicks at 16 PM to all scatterbrained devs. Since then no lacks in timesheet completion
has been observed. However our code hasn't been perfect. It has been sending same girls repeatedly.
Girls sometimes were too plastic. So I decided to improve our legendary reminder mechanism, by
recreating it...

So - it finally will be configurable windows service which sends e-mail to defined recipient list
with embedded photo and after successful operation adding it to list, to prevent further sending
the same file.