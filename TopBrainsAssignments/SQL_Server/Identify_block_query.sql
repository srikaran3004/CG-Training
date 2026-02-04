select 
    r.session_id as BlockedSession,
    r.blocking_session_id as BlockingSession,
    t.text as SqlText
from sys.dm_exec_requests r
cross apply sys.dm_exec_sql_text(r.sql_handle) t
where r.blocking_session_id <> 0;

-- Refer later for revision--