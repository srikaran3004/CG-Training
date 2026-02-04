sp_help COURSE_INFO;

select ZIP_CODE, CITY, STATE as StateName from ZIPCODE_INFO;

select distinct STATE from ZIPCODE_INFO;

select STUDENT_ID, STUDENT_FIRST_NAME + ' ' + STUDENT_LAST_NAME as FullName
from STUDENT_INFO;

select ZIP_CODE + ', ' + CITY + ', ' + STATE as Address
from ZIPCODE_INFO;

select COURSE_NAME, COST from COURSE_INFO;

select * from COURSE_INFO;

select INSTRUCTOR_LAST_NAME, ZIP_CODE from INSTRUCTOR_INFO;

select distinct ZIP_CODE from STUDENT_INFO;

select STUDENT_FIRST_NAME, STUDENT_LAST_NAME from STUDENT_INFO;

select CITY, STATE, ZIP_CODE from ZIPCODE_INFO;

select STUDENT_ID, SECTION_ID, NUMERIC_GRADE
from GRADE_INFO
where GRADE_TYPE_CODE = 'FI';

select ZIP_CODE, CITY from ZIPCODE_INFO where STATE = 'MI';

select SECTION_ID, INSTRUCTOR_ID
from SECTION_INFO
where COURSE_NO in (10,20)
order by INSTRUCTOR_ID;

select STUDENT_ID, SECTION_ID, NUMERIC_GRADE
from GRADE_INFO
order by SECTION_ID asc, NUMERIC_GRADE desc;

select COURSE_NO, COURSE_NAME, COST
from COURSE_INFO
where COURSE_NAME like '%Intro%';

select * from STUDENT_INFO where STUDENT_ID between 300 and 350;

select * from COURSE_INFO where COST between 4000 and 7000;

select COURSE_NAME, COST from COURSE_INFO where COST > 4000;

select COURSE_NAME, COST from COURSE_INFO where COST between 3000 and 7000;

select STUDENT_FIRST_NAME, STREET_ADDRESS
from STUDENT_INFO
where STUDENT_LAST_NAME like 'S%';

select CITY + ', ' + STATE as Location from ZIPCODE_INFO;

select upper(left(STUDENT_FIRST_NAME,1)) + lower(substring(STUDENT_FIRST_NAME,2,len(STUDENT_FIRST_NAME)))
from STUDENT_INFO;

select INSTRUCTOR_FIRST_NAME + ', ' + INSTRUCTOR_LAST_NAME from INSTRUCTOR_INFO;

select COST,
       COST + 10 as Add10,
       COST - 20 as Sub20,
       COST * 30 as Mul30,
       COST / 5 as Div5
from COURSE_INFO;

select COURSE_NAME,
       case when COURSE_PREREQUISITE is null then 'Not Applicable'
            else cast(COURSE_PREREQUISITE as varchar)
       end as Prerequisite
from COURSE_INFO;

select CITY,
       case STATE
            when 'NY' then 'New York'
            when 'NJ' then 'New Jersey'
            else 'Others'
       end as StateFull
from ZIPCODE_INFO;
