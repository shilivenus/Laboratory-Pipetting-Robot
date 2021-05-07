# Laboratory-Pipetting-Robot


收到来自Charmaine Thum的新邮件  显示  忽略

跳至内容
通过屏幕阅读器使用 Gmail
会议
发起新会议
加入会议
Hangouts

第 2 个会话，共 3,461 个
MyDNA: .NET Developer Coding Tech Test - Please complete this weekend
收件箱

Charmaine Thum
附件
下午1:59 (4小时前)
发送至 Charmaine、 Michael、 Kimberley、 密送：我

   
翻译邮件
对英语停用
Good Afternoon,

We have submitted your resume to MyDNA Life and congratulations!

They would like to pass you from a .NET Developer tech test as per attached.

Are you able to complete this over the weekend and send me back the results by say Sunday 9th May 5.30PM?

Feel free to advise if you need more time but we look forward to hearing from you regarding your completed tech test!

Charmaine



Charmaine Thum

Charmaine Thum

New Business & Development Manager

+61 3 9020 1996 / 0439 320 538

cthum@siriustechnology.com.au

L2, 517 Flinders Lane, Melbourne, VIC 3000 

siriuspeople.com.au

LinkedIn  YouTube  Facebook  Instagram  Twitter  Please leave a review!  Most APSCo-certified recruitment partner in Australia

                              
 Download the Salary Guide FY 20/21 now >>
                               
2 个附件

Li Shi
下午2:59 (3小时前)
发送至 Charmaine

Hi Charmaine

I really do not time for this weekend. I think it will take two days to finish. I can start work on it in next Monday. Thank you.

Regards

Peter

Charmaine Thum <cthum@siriustechnology.com.au> 于2021年5月7日周五 下午1:59写道：

Description:
. The application is a simulation of a laboratory pipetting robot arm moving above a square plate of 25 wells, of dimensions 5 units x 5 units.
. The robot is free to roam above the surface of the plate, but must be prevented from moving beyond the boundaries of the plate. Any movement 
that would result in the robot arm overshooting the plate must be prevented, however further valid movement commands must still 
be allowed.
-Assume that the robot has been primed with enough solution to pipette.


. Create an application that can read in commands of the following form -
PLACE X,Y
DETECT
DROP
MOVE N, S, E or W
REPORT

. PLACE will place the robot above the plate in position X,Y. 
. The origin (0,0) can be considered to be the SOUTH WEST most corner.
. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
. MOVE will move the toy robot one well in the direction specified by the command.
. DETECT will sense whether the well directly below is FULL, EMPTY or ERR (if the robot cannot detect the plate)
. DROP place a drop of liquid into the well directly below the robot
. REPORT will announce the X,Y,FULL/EMPTY (the status of the detection of the well below) of the robot arm. This can be in any form, but standard output is sufficient.

. A robot that is not over the plate can choose the ignore the MOVE and REPORT commands.
. Input can be from a file, or from standard input, as the developer chooses.
. Provide test data to exercise the application. Test data should include priming the plate with wells that are EMPTY or FULL.


Constraints:
The toy robot must not overshoot  the table during movement. This also includes the initial placement of the toy robot. 
Any move that would cause the robot to fall must be ignored.

Example Input and Output:
a)
PLACE 0,0
MOVE N
REPORT
Output: 1,0,EMPTY

b)
PLACE 0,0
MOVE E
REPORT
Output: 0,1,FULL

c)
PLACE 1,2
MOVE N
MOVE E
REPORT
Output: 2,3,EMPTY

Robot Coding Puzzle 2.txt
当前显示Robot Coding Puzzle 2.txt。
