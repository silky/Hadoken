﻿CREATE TABLE IF NOT EXISTS public.Group
(
  ID SERIAL NOT NULL,
  Number INTEGER NOT NULL,
  Name CHARACTER VARYING(10),
  IUPAC CHARACTER VARYING(10),
  CAS CHARACTER VARYING(5),
  Family CHARACTER VARYING(20),
  DateCreatedUtc TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT timezone('utc'::text, now()),
  DateUpdatedUtc TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT timezone('utc'::text, now()),
  CONSTRAINT group_pkey PRIMARY KEY (ID)
)
WITH (OIDS=FALSE);

ALTER TABLE public.Group OWNER TO postgres;
