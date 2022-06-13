CREATE OR REPLACE FUNCTION bills.get_summary (r_start date, r_end date, prev_start date, prev_end date)
returns table (
    total_wo_rent      numeric,
    total_wo_rent_diff  numeric,
    total_rent        numeric,
    total_rent_diff    numeric
)
language plpgsql
as $$
begin
	return query 
		select
			cur.total_wo_rent,
            case
                when prev.total_wo_rent = 0 then 0
                else cur.total_wo_rent - prev.total_wo_rent
            end,
			cur.total_rent,
            case
                when prev.total_rent = 0 then 0
                else cur.total_rent - prev.total_rent
            end
		from bills.get_total(r_start, r_end) cur
        left join lateral bills.get_total(prev_start, prev_end) prev on true;
end; $$