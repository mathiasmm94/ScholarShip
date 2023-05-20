import Card from "@mui/material/Card";
import Image from "mui-image";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";

export function ProductCard({ Title, ImgSource, category, price, sx }) {
  return (
    <Card sx={sx}>
      <Image src={ImgSource} sx={sx} />
      <Stack spacing={2}>
        <Stack direction={'row'} sx={{justifyContent: 'space-between'}}>
          <Typography>{Title}</Typography>
          <Typography>{price}</Typography>
        </Stack>
        <Stack direction={'row'} sx={{justifyContent: 'space-between'}}>
          <Typography>{category}</Typography>
          <Typography>{price}</Typography>
        </Stack>
      </Stack>
    </Card>
  );
}
