import Card from "@mui/material/Card";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";

export function ProductCard({ Title, ImgSource, category, price, studieRetning, stand, sx }) {
  return (
    <Card variant={'elevation'} sx={{padding: '10px', margin: '10px'}} >
      <img alt="produktbillede" src={ImgSource} sx={sx} />
      <Stack spacing={2}>
        <Stack direction={'row'} sx={{justifyContent: 'space-between'}}>
          <Typography>{Title}</Typography>
          <Typography>{price}</Typography>
        </Stack>
        <Stack direction={'row'} sx={{justifyContent: 'space-between'}}>
          <Typography>{category}</Typography>
          <Typography>{studieRetning}</Typography>
          <Typography>{stand}</Typography>
        </Stack>
      </Stack>
    </Card>
  );
}
