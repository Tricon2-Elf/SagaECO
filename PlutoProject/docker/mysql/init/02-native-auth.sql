-- Host apps (Windows) ->127.0.0.1:3306 appear as 172.x.x.x inside the container.
-- They need an account with host '%' (or that exact IP). Wildcard '%' is portable across Docker subnets.

-- Ensure root can log in from non-localhost clients (NAT / bridge)
CREATE USER IF NOT EXISTS 'root'@'%' IDENTIFIED WITH mysql_native_password BY 'saga';
ALTER USER 'root'@'%' IDENTIFIED WITH mysql_native_password BY 'saga';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;

ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'saga';

FLUSH PRIVILEGES;
