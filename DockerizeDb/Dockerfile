FROM mysql:5.6 

MAINTAINER Yazan Kassam yazankassasm.codavia@gmail.com

ENV MYSQL_DATABASE story_ms_db

# Add the content of the sql-scripts/ directory to your image
# All scripts in docker-entrypoint-initdb.d/ are automatically
# executed during container startup
COPY DockerizeDb/sql-scripts/ /docker-entrypoint-initdb.d/
