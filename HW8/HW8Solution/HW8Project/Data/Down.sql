ALTER TABLE ASSIGNMENTS DROP CONSTRAINT ASSIGNMENTS_FK_COURSE;
ALTER TABLE AssignmentTag DROP CONSTRAINT TAG_FK_ASSIGNMENT;
ALTER TABLE AssignmentTag DROP CONSTRAINT TAG_FK_TAGNAME;

Drop Table AssignmentTag;
Drop Table Assignments;
Drop Table Courses;
Drop Table Tagnames;
