# CollegeManagementApi
final repository

<h1>ROUTES</h1>

COURSES REGISTER VIEW
<table>
	<tr>
		<td>get courses</td>
		<td>http://localhost:36820/api/Courses</td>
		<td>[HttpGet]</td>
	</tr>
	<tr>
		<td>get List of Teachers</td>
		<td>http://localhost:36820/api/Courses/1/Teachers</td>
		<td>[HttpGet("{cid}/Teachers")]</td>
	</tr>
	<tr>
		<td> Register to a course</td>
		<td>http://localhost:36820/api/Registered/1/enroll/1 </td>
		<td>[HttpGet("{sid}/Enroll/{taughtby_id}")]</td>
	</tr>
	<tr>
		<td>get registered courses of student</td>
		<td>http://localhost:36820/api/Registered/3 </td>
		<td>[HttpGet("{sid}")]</td>
	</tr>
  
 </table>
  
STUDENT COURSE PAGE VIEW
<table>
	<tr>
		<td>get registered courses of student</td>
		<td> In COURSES REGISTER VIEW</td>
		<td></td>
	</tr>
	<tr>
		<td>  get project marks</td>
		<td>http://localhost:36820/api/Registered/2/Marks</td>
		<td>[HttpGet("{regid}/Marks")]</td>
	</tr>
	<tr>
		<td> Get Attendance</td>
		<td>http://localhost:36820/api/Attendance/1</td>
		<td>HttpGet("{regid}")]</td>
	</tr>
</table>
