CREATE OR REPLACE FUNCTION bills.get_total (r_start date, r_end date)
returns table (
    total_wo_rent      numeric,
    total_rent        numeric
)
language plpgsql
as $$
begin
	return query 
		select
			COALESCE(SUM(ad.payment + ad.internet + wa.payment + el.payment + re.payment + he.payment), 0),
			COALESCE(SUM(rent.payment), 0)
		from bills.billing b
        left join bills.additionals ad on ad.billing_id = b.id
        left join bills.water wa on wa.billing_id = b.id
        left join bills.electricity el on el.billing_id = b.id
        left join bills.repairs re on re.billing_id = b.id
        left join bills.heating he on he.billing_id = b.id
        
        left join bills.rent rent on rent.billing_id = b.id
		where 1 = (case
                    when r_start is null                  then 1
                    when r_end is null                    then 1
                    when b.date between r_start and r_end then 1
                    else 0
                   end
                  );
end; $$