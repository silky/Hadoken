CREATE OR REPLACE FUNCTION public.spgetelement() RETURNS SETOF public.element AS

$BODY$

SELECT
	id, 
	groupid,
	atomicnumber,
	symbol,
	name,
	period,
	atomicweight, 
	density,
	datecreatedutc,
	dateupdatedutc
FROM
	public.element;

$BODY$

LANGUAGE sql VOLATILE COST 100;
ALTER FUNCTION public.spgetelement() OWNER TO postgres;
