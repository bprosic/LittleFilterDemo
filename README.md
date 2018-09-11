# LittleFilterDemo
To filter data stored in a file separated by semicolons 

I was asked to filter some data stored in a file.
Colleagues wanted to get rows with last three indexes stored in column two (ID_NR_INDEX).
This could be done in Excel using macros. I don't know if Excel would affect performance or loss of information.

I decided using C#.
This could be done in a console, but people are afraid of black windows ;)

There is an example file in folder "Data for manipulation".
This file is just for demonstration. Usually it contains lots of data rows (mine was 7000++).

Open this project in Sharp Develop, run Debugger. 
Drag and drop "someInput.lxt" file into first Text Box,
enter number in second Text Box to enter how many indexes you really want and run Generate.
(I'm using linq to group first column and calculate max three values of second column).

It should create filter file in same directory.

If there is better solution without using regex, please share :)

Input:

1105;16;LIPOLI;111111113;10;19;4,162;5,50;010;1;000;1;55,00;41,624;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;17;LIPOLI;111111113;10;19;4,229;5,60;010;1;000;1;56,00;42,293;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;18;LIPOLI;111111113;10;20;4,525;6,00;010;1;000;1;60,00;45,251;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;19;LIPOLI;111111113;10;20;4,721;6,30;010;1;000;1;63,00;47,206;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;20;LIPOLI*;111111113;10;20;4,790;6,40;010;1;000;1;64,00;47,905;811111113;;;,00;0;0;,00;;;;;;;;;;

1106;16;LIPOLI FI.GOLD.BLEND;111111115;10;19;4,162;5,50;010;1;000;1;55,00;41,624;811111115;;;,00;0;0;,00;;;;;;;;;;
1106;17;LIPOLI*FI.GOLD.BLEND#;111111115;10;19;4,229;5,60;010;1;000;1;56,00;42,293;811111115;;;,00;0;0;,00;;;;;;;;;;

(...)

Output the result:

1105;18;LIPOLI;111111113;10;20;4,525;6,00;010;1;000;1;60,00;45,251;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;19;LIPOLI;111111113;10;20;4,721;6,30;010;1;000;1;63,00;47,206;811111113;;;,00;0;0;,00;;;;;;;;;;
1105;20;LIPOLI*;111111113;10;20;4,790;6,40;010;1;000;1;64,00;47,905;811111113;;;,00;0;0;,00;;;;;;;;;;

1106;16;LIPOLI FI.GOLD.BLEND;111111115;10;19;4,162;5,50;010;1;000;1;55,00;41,624;811111115;;;,00;0;0;,00;;;;;;;;;;
1106;17;LIPOLI*FI.GOLD.BLEND#;111111115;10;19;4,229;5,60;010;1;000;1;56,00;42,293;811111115;;;,00;0;0;,00;;;;;;;;;;

(...)
