INSERT INTO Courses([NAME]) VALUES
	('CS460'),
	('CS363'),
	('BA490');

INSERT INTO Assignments(IMPORTANCE, DUE, TITLE, NOTES, COURSEID) VALUES
	('1', '11-1-2020 11:49:00', 'Homework #5: C#,SQL', 'Assignment Tracker', '1'),
	('3', '11-8-2020 11:53:00', 'Homework #6', 'Using the chinook database', '2'),
	('5', '11-5-2020 11:51:00', 'Homework #7', 'Using APIs', '3');

INSERT INTO Tagnames(TAGNAME) VALUES
	('Hard'),
	('Easy'),
	('Long'),
	('Quick'),
	('Coding'),
	('Reading');

INSERT INTO AssignmentTag(ASSIGNMENTID, TAGNAMEID) VALUES
	('1','2'),
	('2','5');