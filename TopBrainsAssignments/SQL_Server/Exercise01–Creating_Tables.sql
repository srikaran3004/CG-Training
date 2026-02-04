create table ZIPCODE_INFO (
    ZIP_CODE varchar(5),
    CITY varchar(10)
);

create table INSTRUCTOR_INFO (
    INSTRUCTOR_ID numeric(8,0),
    INSTRUCTOR_FIRST_NAME varchar(15),
    INSTRUCTOR_LAST_NAME varchar(15)
);

create table COURSE_INFO (
    COURSE_NO numeric(8,0),
    COST numeric(5,2)
);

create table STUDENT_INFO (
    STUDENT_ID numeric(8,0),
    STUDENT_FIRST_NAME varchar(15),
    STUDENT_LAST_NAME varchar(15)
);

create table SECTION_INFO (
    SECTION_ID numeric(8,0),
    COURSE_NO numeric(8,0),
    SECTION_NO numeric(5),
    INSTRUCTOR_ID numeric(8,0)
);

create table ENROLLMENT_INFO (
    STUDENT_ID numeric(8,0),
    SECTION_ID numeric(8,0)
);

create table GRADE_INFO (
    STUDENT_ID numeric(8,0),
    SECTION_ID numeric(8,0),
    GRADE_TYPE_CODE char(2),
    GRADE_CODE_OCCURANCE numeric(5)
);
