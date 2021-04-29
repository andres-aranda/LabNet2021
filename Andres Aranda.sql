USE PracticaSQL;
-- 1-	Recuperar lista de empleados

SELECT emp.LAST_NAME	AS 'Apellido',
		emp.FIRST_NAME	AS 'Nombre'
FROM TEST.EMPLOYEES		AS emp;

-- 2-	Recuperar id, apellido, fecha de contratación de los empleados
SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp;

--3-	Recuperar id, apellido, fecha de contratación, salario de los empleados. 
--Tip: notar presencia de valores nulos

SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		ISNULL(emp.SALARY,0)		AS 'Salario',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp;

--4-	Recuperar id, apellido, fecha de contratación, salario anual de los empleados. 
--Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual.

SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		ISNULL(emp.SALARY,0)*12		AS 'Salario anual',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp;

--5-	Recuperar id, apellido y nombre, fecha de contratación, salario anual de los empleados. Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de los campos.

SELECT emp.ID,
		emp.LAST_NAME + emp.FIRST_NAME				AS 'Apellido y nombre',
		ISNULL(emp.SALARY,0)*12						AS 'Salario anual',
		CONVERT(date,emp.HIRE_DATE)					AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp;

--6-	Recuperar lista de departamentos que tienen empleados:
--		6.a- Recuperar lista de departamentos de los empleados

SELECT dep.DEPARTMENT_NAME AS 'Departamento'
FROM TEST.EMPLOYEES			AS emp
	JOIN TEST.DEPARTMENTS	AS dep
		ON emp.DEPARTMENT_ID=dep.ID;

--6.b- Recuperar lista no repetida de departamentos de los empleados

SELECT dep.DEPARTMENT_NAME AS 'Departamento'
FROM TEST.EMPLOYEES			AS emp
	JOIN TEST.DEPARTMENTS	AS dep
		ON emp.DEPARTMENT_ID=dep.ID
GROUP BY dep.DEPARTMENT_NAME;

--7-	Recuperar lista de empleados cuyo departamento sea 10.

SELECT emp.LAST_NAME	AS 'Apellido',
		emp.FIRST_NAME	AS 'Nombre'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.DEPARTMENT_ID=10;

--8-	Recuperar lista de empleados cuyo salario sea menor a 2000.
-- (Se asumio com que los "nulls" son menores a 2000)

SELECT emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre',
		ISNULL(emp.SALARY,0)	AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.SALARY<2000 or emp.SALARY IS NULL;

--9-	Recuperar lista de empleados cuyo salario sea entre 1800 y 3000 Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones.

SELECT  emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre',
		emp.SALARY				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.SALARY BETWEEN 1800 AND 3000;

--10-	Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31. Tip: usar cláusula “in”.

SELECT  emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre',
		emp.DEPARTMENT_ID		AS 'Departamento'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.DEPARTMENT_ID in (10,30,31);

--11-	Recuperar lista de empleados cuyo apellido empiece con F.
--Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de dato de los campos.
SELECT  emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.LAST_NAME LIKE 'F%';

--12-	Recuperar lista de empleados cuyo job_id:
--12.a- no hay sido definido
SELECT  emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.JOB_ID IS NULL;

--12.b- haya sido definido.
SELECT  emp.LAST_NAME			AS 'Apellido',
		emp.FIRST_NAME			AS 'Nombre',
		emp.JOB_ID				AS 'ID job'
FROM TEST.EMPLOYEES		AS emp
WHERE emp.JOB_ID IS NOT NULL;

--13-	Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’.
--Tip: Notar comportamiento de la condición con jobs nulos.
--No todos los empleados tienen jobs

SELECT  emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')	AS 'ID job'
FROM TEST.EMPLOYEES		AS emp
WHERE  NOT emp.JOB_ID='AD_CTB' or emp.JOB_ID IS NULL;

--14-	Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ y cuyo salario sea mayor a 1900.
SELECT  emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')			AS 'ID job',
		ISNULL(emp.SALARY,0)				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE	(NOT emp.JOB_ID='AD_CTB' OR emp.JOB_ID IS NULL)
		AND SALARY > 1900;

--15-	Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ o cuyo salario sea mayor a 1900.
SELECT  emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')			AS 'ID job',
		ISNULL(emp.SALARY,0)				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE	NOT emp.JOB_ID='AD_CTB' 
		OR emp.JOB_ID IS NULL
		OR SALARY > 1900;

-- VARIANTE POR "O" EXCLUYENTE

DROP TABLE IF EXISTS #EMP_INTERSECTION_TEMP;
CREATE TABLE #EMP_INTERSECTION_TEMP (ID int);
INSERT INTO  #EMP_INTERSECTION_TEMP
      SELECT  emp.ID
FROM TEST.EMPLOYEES		AS emp
WHERE	(NOT emp.JOB_ID='AD_CTB' OR emp.JOB_ID IS NULL)
		AND SALARY > 1900;

SELECT  emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')			AS 'ID job',
		ISNULL(emp.SALARY,0)				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE	(NOT emp.JOB_ID='AD_CTB' 
		OR emp.JOB_ID IS NULL
		OR SALARY > 1900)
		AND emp.ID NOT IN (SELECT temp.ID 
								FROM #EMP_INTERSECTION_TEMP AS temp);
DROP TABLE IF EXISTS #EMP_INTERSECTION_TEMP;

--16-	Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar IN) y cuyo salario sea mayor a 1900.
--Tip: Probar precedencia de condiciones con o sin paréntesis.
SELECT  id,emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')			AS 'ID job',
		ISNULL(emp.SALARY,0)				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE   (emp.JOB_ID='AD_CTB' 
		OR emp.JOB_ID='FQ_GRT') 
		AND SALARY > 1900;

SELECT  id,emp.LAST_NAME						AS 'Apellido',
		emp.FIRST_NAME						AS 'Nombre',
		ISNULL(emp.JOB_ID,'SinJob')			AS 'ID job',
		ISNULL(emp.SALARY,0)				AS 'Salario'
FROM TEST.EMPLOYEES		AS emp
WHERE   emp.JOB_ID='AD_CTB' 
		OR emp.JOB_ID='FQ_GRT' 
		AND SALARY > 1900;

--OBSERVACIONES En base a las condiciones que solicita el enunciado no pude 
-- deducir reglas de como es el comportamiento de las sentencia con o sin ()
-- modifique los valores para tener un grupo mas ampli de comparacion y 
-- note que las operaciones respetan las reglas de union y separacion de terminos
-- en matematicas producto (AND) une termminos adicion (OR) separa

--17-	Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más nuevo).

SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		emp.FIRST_NAME				AS 'Nombre',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp
ORDER BY emp.HIRE_DATE;


--18-	Recuperar empleados ordenados por fecha de ingreso (desde más nuevo a más viejo).

SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		emp.FIRST_NAME				AS 'Nombre',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp
ORDER BY emp.HIRE_DATE DESC;

--19-	Recuperar empleados ordenados por fecha de ingreso descendente y apellido ascendente.
SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		emp.FIRST_NAME				AS 'Nombre',
		CONVERT(date,emp.HIRE_DATE)	AS 'Fecha de contratacion'
FROM TEST.EMPLOYEES		AS emp
ORDER BY emp.HIRE_DATE DESC ,
		 emp.LAST_NAME;

--20-	Recuperar apellido y salario anual de empleados ordenados por salario anual.
--Tip: Usar alias de columna para ordenar por salario anual.

SELECT emp.ID,
		emp.LAST_NAME				AS 'Apellido',
		ISNULL(emp.SALARY,0)*12		AS 'Salario anual'
FROM TEST.EMPLOYEES		AS emp
ORDER BY 'Salario anual' DESC;

--21-	Recuperar lista de empleados  con la descripción del departamento al que cada uno pertenece.
--Tip: evitar producto cartesiano.
-- comentario: El producto cartesiano entre tablas devuelve todas las posibles convinaciones entre las tablas

SELECT	emp.LAST_NAME	AS 'Apellido',
		emp.FIRST_NAME	AS 'Nombre',
		ISNULL(dep.DEPARTMENT_DESCRIPTION,'Sin desc/No asig.') AS 'Descripcion del departamento'
FROM TEST.EMPLOYEES				AS emp
	LEFT JOIN TEST.DEPARTMENTS	AS dep 
		ON emp.DEPARTMENT_ID=dep.ID;


--22-	Seleccionar apellido de empleado y nombre de departamento
SELECT	emp.LAST_NAME							AS 'Apellido',
		ISNULL(dep.DEPARTMENT_NAME,'No asignado')	AS 'Departamento'
FROM	TEST.EMPLOYEES				AS emp
		LEFT JOIN TEST.DEPARTMENTS	AS dep 
			ON emp.DEPARTMENT_ID=dep.ID;

--23-	Agregar id de empleado y id de departamento
--Tip: desambiguar campos usando alias de tablas.

SELECT	emp.ID										AS 'ID empleado',
		emp.LAST_NAME								AS 'Apellido',
		ISNULL(dep.DEPARTMENT_NAME,'No asignado')	AS 'Departamento',
		dep.ID										AS 'ID departamento'
FROM	TEST.EMPLOYEES				AS emp
		LEFT JOIN TEST.DEPARTMENTS	AS dep 
			ON emp.DEPARTMENT_ID=dep.ID;

--24-	Recuperar lista de empleados con descipción de departamentos y ciudades.

SELECT	emp.LAST_NAME								AS 'Apellido',
		emp.FIRST_NAME								AS 'Nombre', 
		ISNULL(dep.DEPARTMENT_NAME,'No asignado')	AS 'Departamento',
		loc.CITY									AS 'Ciudad'
FROM	TEST.EMPLOYEES							AS emp
		LEFT JOIN TEST.DEPARTMENTS				AS dep 
			ON emp.DEPARTMENT_ID=dep.ID
		LEFT JOIN TEST.LOCATIONS				AS loc		 
			ON dep.LOCATION_ID=loc.ID;

--25-	Recuperar lista de empleados  con la descripción del departamento al que cada uno pertenece.
SELECT	emp.LAST_NAME	AS 'Apellido',
		emp.FIRST_NAME	AS 'Nombre',
		ISNULL(dep.DEPARTMENT_DESCRIPTION,'Sin descripcion') AS 'Descripcion del departamento'
FROM TEST.EMPLOYEES				AS emp
		JOIN TEST.DEPARTMENTS	AS dep 
		ON emp.DEPARTMENT_ID=dep.ID;

--26-	Recuperar lista de empleados  con la descripción del departamento, tengan o no departamento asignado.

SELECT	emp.LAST_NAME	AS 'Apellido',
		emp.FIRST_NAME	AS 'Nombre',
		ISNULL(dep.DEPARTMENT_DESCRIPTION,'Sin desc/No asig.') AS 'Descripcion del departamento'
FROM TEST.EMPLOYEES				AS emp
	LEFT JOIN TEST.DEPARTMENTS	AS dep 
		ON emp.DEPARTMENT_ID=dep.ID;


--27-	Recuperar lista de departamentos con empleados de cada departamento, tengan o no empleados asociados.

SELECT  dep.DEPARTMENT_NAME										AS 'Departamento',
		ISNULL(emp.LAST_NAME+' '+emp.FIRST_NAME,'Sin empleados')	AS 'Apellido y nombre'
FROM TEST.DEPARTMENTS			AS dep
	LEFT JOIN TEST.EMPLOYEES	AS emp
		ON dep.ID=emp.DEPARTMENT_ID;

--28-	Recuperar lista de subordinados por cada manager 

SELECT	emp.LAST_NAME+' '+emp.FIRST_NAME	AS 'Empleado',
		man.LAST_NAME+' '+man.FIRST_NAME	AS 'Manager'
FROM TEST.EMPLOYEES AS emp
	JOIN TEST.EMPLOYEES AS man
		ON emp.MANAGER_ID = man.ID;

--29-	Recuperar máximo salario de los empleados.

SELECT MAX(emp.SALARY)		AS 'Salario maximo'
FROM TEST.EMPLOYEES emp;


--30-	Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.

SELECT	MAX(emp.SALARY)				AS 'Salario maximo',
		MIN(emp.SALARY)				AS 'Salario minimo',
		AVG(emp.SALARY)				AS 'Promedio sin nulos',
		AVG(ISNULL(emp.SALARY,0))	AS 'Promedio con nulos',
		SUM(emp.SALARY)				AS 'Suma total'
FROM TEST.EMPLOYEES emp;

--31-	Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de los empleados.
--Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de dato.
-- 
SELECT	MAX(emp.SALARY)						AS 'Salario maximo',
		MIN(emp.SALARY)						AS 'Salario minimo',
		AVG(emp.SALARY)						AS 'Promedio sin nulos',
		AVG(ISNULL(emp.SALARY,0))			AS 'Promedio con nulos',
		SUM(CAST(emp.HIRE_DATE AS INT))		AS 'Suma total'
FROM TEST.EMPLOYEES emp;

--32-	Obtener la cantidad de empleados.

SELECT	count(emp.ID)	AS 'Cantidad de empleados'		
FROM TEST.EMPLOYEES emp;

--33-	Obtener la cantidad de empleados cuyo departamento sea 10.

SELECT	count(emp.ID)	AS 'Cantidad de empleados dep 10'		
FROM TEST.EMPLOYEES emp
WHERE emp.DEPARTMENT_ID=10;

--34-	Obtener la cantidad de empleados de cada departamento.

SELECT	dep.DEPARTMENT_NAME	AS 'Departamento',
		count(emp.ID)		AS 'Cantidad de empleados'		
FROM TEST.DEPARTMENTS			AS dep
		LEFT JOIN TEST.EMPLOYEES	AS emp
		ON dep.ID=emp.DEPARTMENT_ID
GROUP BY dep.DEPARTMENT_NAME;

--35-	Obtener la cantidad de empleados por cada departamento y job.

SELECT	dep.DEPARTMENT_NAME	AS 'Departamento',
		job.JOB_NAME		AS 'Rol',
		count(emp.ID)		AS 'Cantidad de empleados'		
FROM TEST.DEPARTMENTS			AS dep
		LEFT JOIN TEST.EMPLOYEES	AS emp
		ON dep.ID=emp.DEPARTMENT_ID
		LEFT JOIN TEST.JOBS job
			ON emp.JOB_ID=job.ID
GROUP BY dep.DEPARTMENT_NAME,job.JOB_NAME;

--36-	Recuperar los departamentos y el salario promedio de cada departamento.

SELECT	dep.DEPARTMENT_NAME				AS 'Departamento',
		ISNULL(AVG(emp.SALARY),0)		AS 'Salario promedio'		
		FROM TEST.DEPARTMENTS		AS dep
		LEFT JOIN TEST.EMPLOYEES	AS emp
		ON dep.ID=emp.DEPARTMENT_ID
GROUP BY dep.DEPARTMENT_NAME;

--37-	Recuperar los departamentos y el salario promedio si es menor a 1200.	
SELECT	dep.DEPARTMENT_NAME				AS 'Departamento',
		ISNULL(AVG(emp.SALARY),0)		AS 'Salario promedio'		
		FROM TEST.DEPARTMENTS		AS dep
		LEFT JOIN TEST.EMPLOYEES	AS emp
		ON dep.ID=emp.DEPARTMENT_ID
GROUP BY dep.DEPARTMENT_NAME
HAVING ISNULL(AVG(emp.SALARY),0) < 1200;

--38-	Crear un nuevo departamento
--38.a- Caso 1: Crear insert de todos los campos en orden.
--Tip: Notar restricciones de integridad por padre inexistente y por clave duplicada.
--Debe existir la referencia de la fk que se ingresa y el ID no puede ser duplicado
GO
BEGIN TRANSACTION;

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.DEPARTMENTS
     VALUES (@idMax,'Marketing',1, 'Prensa');

COMMIT TRANSACTION;
GO
--38.b- Caso 2: Crear insert de todos los campos en orden usando valores nulos.
--Tip: Notar restricciones de no nulidad.
--Ciertos campos no permiten nulos en su ingreso
GO
BEGIN TRANSACTION;

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.DEPARTMENTS
     VALUES (NULL,NULL,NULL,NULL);

COMMIT TRANSACTION;
GO
--38.c- Crear insert usando solamente los campos obligatorios.
--Tip: Especificar lista de campos obligatorios.
GO
BEGIN TRANSACTION

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.DEPARTMENTS
           (ID,
		   DEPARTMENT_NAME,
		   LOCATION_ID)
     VALUES(@idMax, 'RRHH',1);
COMMIT TRANSACTION;
GO
/*39-	Crear un nuevo empleado basado en los datos de Gustavo Boulette:
●	cambiando su nombre
●	aumentando su sueldo en $200.
●	blanqueando su manager */
GO
BEGIN TRANSACTION

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.EMPLOYEES
SELECT @idMax , 'Pepito', 'Gomez',emp.SALARY+200,emp.DEPARTMENT_ID,emp.JOB_ID,emp.HIRE_DATE,NULL
FROM TEST.EMPLOYEES emp
WHERE emp.FIRST_NAME='Gustavo' and emp.LAST_NAME='Boulette';

COMMIT TRANSACTION;
GO
--40-	Actualizar salario del empleado 10 a $1100.

BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=1100
 WHERE  ID=10;
COMMIT TRANSACTION;

--41-	Duplicar salario del empleado 11.

BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=SALARY*2
 WHERE  ID=11;
COMMIT TRANSACTION;

--42-	Aumentar salario en un 10% a todos los empleados del departamento 40.

BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=SALARY*1.1
WHERE  DEPARTMENT_ID=40;
COMMIT TRANSACTION;

--43-	Eliminar departamentos cuyo id sea mayor a 50.
--Tip: hacer un select antes y después para verificar usando la misma condición que para el delete.

BEGIN TRANSACTION

SELECT ID
FROM TEST.DEPARTMENTS;

DELETE TEST.DEPARTMENTS 
WHERE  ID>50;

SELECT ID
FROM TEST.DEPARTMENTS;

COMMIT TRANSACTION;

--44-	Eliminar departamento 40.
--Tip: notar resultado de las restricciones de integridad.
--OBS:Se debe borrar todos los lugares en donde se hace referencia al dato
Select * from TEST.DEPARTMENTS;

BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET DEPARTMENT_ID=NULL
WHERE  DEPARTMENT_ID=40

DELETE TEST.DEPARTMENTS 
WHERE  ID=40;
COMMIT TRANSACTION;

--rollback;

/* 45-	Crear la función "fn_AntiguedadEmpleado" 
que retorne la antiguedad en años de cada empleado
donde el parametro de ingreso es el id del empleado */
GO
CREATE FUNCTION fn_AntiguedadEmpleado(@id INT)
RETURNS INT
AS
BEGIN
DECLARE @Antiguiedad int

SELECT @Antiguiedad = DATEDIFF (YEAR, emp.HIRE_DATE , GETDATE())
FROM TEST.EMPLOYEES AS emp
	WHERE emp.ID=@id

RETURN @Antiguiedad
END
GO


SELECT dbo.fn_AntiguedadEmpleado(1);

/*46 - Crear el Procedimiento almacenado "sp_GetNombreAntiguedad" que retorne el primer nombre y el apellido separados por una coma y en la segunda columna la antiguedad en año. Usar la función creada en el punto anterior. 
Ordenar por antiguedad descendiente (mas antiguo primero*/
GO
CREATE PROCEDURE sp_GetNombreAntiguedad
AS
SELECT First_name +','+Last_Name, dbo.fn_AntiguedadEmpleado(emp.ID) AS 'Antiguedad'
FROM TEST.EMPLOYEES AS emp
ORDER BY  'Antiguedad'
GO

sp_GetNombreAntiguedad;