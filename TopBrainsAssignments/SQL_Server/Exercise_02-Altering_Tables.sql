alter table ZIPCODE_INFO modify (ZIP_CODE varchar2(5));
alter table ZIPCODE_INFO modify (CITY varchar2(25));
alter table ZIPCODE_INFO modify (STATE varchar2(2));

alter table INSTRUCTOR_INFO modify (INSTRUCTOR_ID number(8,0));
alter table INSTRUCTOR_INFO modify (INSTRUCTOR_FIRST_NAME varchar2(25));
alter table INSTRUCTOR_INFO modify (INSTRUCTOR_LAST_NAME varchar2(25));
alter table INSTRUCTOR_INFO modify (STREET_ADDRESS varchar2(50));
alter table INSTRUCTOR_INFO modify (ZIP_CODE varchar2(5));

alter table COURSE_INFO modify (COURSE_NO number(8,0));
alter table COURSE_INFO modify (COURSE_NAME varchar2(50));
alter table COURSE_INFO modify (COURSE_PREREQUISITE number(8,0));
alter table COURSE_INFO modify (COST number(9,2));

alter table STUDENT_INFO modify (STUDENT_ID number(8,0));
alter table STUDENT_INFO modify (STUDENT_FIRST_NAME varchar2(25));
alter table STUDENT_INFO modify (STUDENT_LAST_NAME varchar2(25));
alter table STUDENT_INFO modify (STREET_ADDRESS varchar2(50));
alter table STUDENT_INFO modify (ZIP_CODE varchar2(5));

alter table SECTION_INFO modify (SECTION_ID number(8,0));
alter table SECTION_INFO modify (COURSE_NO number(8,0));
alter table SECTION_INFO modify (SECTION_NO number(3,0));
alter table SECTION_INFO modify (INSTRUCTOR_ID number(8,0));
alter table SECTION_INFO modify (LOCATION varchar2(50));
alter table SECTION_INFO modify (CAPACITY number(3,0));

alter table ENROLLMENT_INFO modify (STUDENT_ID number(8,0));
alter table ENROLLMENT_INFO modify (SECTION_ID number(8,0));
alter table ENROLLMENT_INFO modify (ENROLLMENT_DATE date);

alter table GRADE_INFO modify (STUDENT_ID number(8,0));
alter table GRADE_INFO modify (SECTION_ID number(8,0));
alter table GRADE_INFO modify (GRADE_TYPE_CODE char(2));
alter table GRADE_INFO modify (GRADE_CODE_OCCURANCE number(38,0));
alter table GRADE_INFO modify (NUMERIC_GRADE number(3,0));
