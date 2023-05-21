import Card from "@mui/material/Card";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";

export function ProductCard({ Title, ImgSource, category, price, studieRetning, stand }) {
  return (
    <Card variant={'elevation'} sx={{padding: '10px', margin: '10px'}} >
      <Stack spacing={10} direction={'row'}>
        
      <img alt="produktbillede" src={ImgSource} width={'150px'} />
        <Stack spacing={12} direction={'row'} sx={{justifyContent: 'space-between'}}>
        <div>Titel på bogen: <Typography fontWeight={'bold'}> {Title}</Typography></div>
        <div>Pris: <Typography fontWeight={'bold'}> {price} DKK.</Typography></div>
            <div>Kategori: <Typography fontWeight={'bold'}> {category}</Typography></div>
            <div>Studieretning: <Typography fontWeight={'bold'}> {studieRetning}</Typography></div>
            <div>Varens stand: <Typography fontWeight={'bold'}> {stand}</Typography></div>
        </Stack>
      </Stack>
    </Card>
  );
}
