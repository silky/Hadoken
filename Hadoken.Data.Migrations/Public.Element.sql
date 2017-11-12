CREATE TABLE IF NOT EXISTS public.Element
(
  ID SERIAL NOT NULL,
  GroupID INTEGER NULL,
  AtomicNumber INTEGER NOT NULL,
  Symbol CHARACTER VARYING(2),
  Name CHARACTER VARYING(20),
  Period INTEGER,
  AtomicWeight DOUBLE PRECISION,
  Density DOUBLE PRECISION,
  DateCreatedUtc TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT timezone('utc'::text, now()),
  DateUpdatedUtc TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT timezone('utc'::text, now()),
  CONSTRAINT element_pkey PRIMARY KEY (ID)
)
WITH (OIDS=FALSE);

ALTER TABLE public.Group OWNER TO postgres;

CREATE INDEX fki_element_fk_groupid ON public.Element USING BTREE (GroupID);