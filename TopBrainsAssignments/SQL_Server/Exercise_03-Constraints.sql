alter table ZIPCODE_INFO
add constraint ZIP_PK primary key (ZIP_CODE);

alter table ZIPCODE_INFO
modify CITY constraint ZIP_CITY_NN not null;

alter table ZIPCODE_INFO
modify STATE constraint ZIP_STATE_NN not null;


alter table INSTRUCTOR_INFO
add constraint INSTRUCTOR_ID_PK primary key (INSTRUCTOR_ID);

alter table INSTRUCTOR_INFO
modify INSTRUCTOR_FIRST_NAME constraint INSTRUCTOR_FN_NN not null;

alter table INSTRUCTOR_INFO
modify INSTRUCTOR_LAST_NAME constraint INSTRUCTOR_LN_NN not null;

alter table INSTRUCTOR_INFO
add constraint ZIP_INSTRUCTOR_FK foreign key (ZIP_CODE)
references ZIPCODE_INFO(ZIP_CODE);


alter table COURSE_INFO
add constraint COURSE_NO_PK primary key (COURSE_NO);

alter table COURSE_INFO
modify COURSE_NAME constraint COURSE_NAME_NN not null;

alter table COURSE_INFO
modify COST constraint COST_NN not null;


alter table STUDENT_INFO
add constraint STUDENT_ID_PK primary key (STUDENT_ID);

alter table STUDENT_INFO
modify STUDENT_FIRST_NAME constraint STUDENT_FN_NN not null;

alter table STUDENT_INFO
modify STUDENT_LAST_NAME constraint STUDENT_LN_NN not null;

alter table STUDENT_INFO
add constraint ZIP_STUDENT_FK foreign key (ZIP_CODE)
references ZIPCODE_INFO(ZIP_CODE);


alter table SECTION_INFO
add constraint SECTION_ID_PK primary key (SECTION_ID);

alter table SECTION_INFO
modify SECTION_NO constraint SECTION_NO_NN not null;

alter table SECTION_INFO
add constraint COURSE_SECTION_FK foreign key (COURSE_NO)
references COURSE_INFO(COURSE_NO);

alter table SECTION_INFO
add constraint INSTRUCTOR_SECTION_FK foreign key (INSTRUCTOR_ID)
references INSTRUCTOR_INFO(INSTRUCTOR_ID);


alter table ENROLLMENT_INFO
add constraint ENROLLMENT_STUD_SECT_PK primary key (STUDENT_ID, SECTION_ID);

alter table ENROLLMENT_INFO
add constraint ENROLLMENT_STUDENT_ID_FK foreign key (STUDENT_ID)
references STUDENT_INFO(STUDENT_ID);

alter table ENROLLMENT_INFO
add constraint ENROLLMENT_SECTION_ID_FK foreign key (SECTION_ID)
references SECTION_INFO(SECTION_ID);


alter table GRADE_INFO
add constraint GRADE_STUD_SECT_TYPE_CODE_PK
primary key (STUDENT_ID, SECTION_ID, GRADE_TYPE_CODE, GRADE_CODE_OCCURANCE);

alter table GRADE_INFO
add constraint GRADE_STUDENT_ID_FK foreign key (STUDENT_ID)
references STUDENT_INFO(STUDENT_ID);

alter table GRADE_INFO
add constraint GRADE_SECTION_ID_FK foreign key (SECTION_ID)
references SECTION_INFO(SECTION_ID);

alter table GRADE_INFO
add constraint CHK_GRADE_TYPE_CODE
check (GRADE_TYPE_CODE in ('FI','HM','MT','PA','PJ','QZ'));

alter table GRADE_INFO
modify NUMERIC_GRADE constraint NUMERIC_GRADE_NN not null;

alter table GRADE_INFO
modify NUMERIC_GRADE default 0;
