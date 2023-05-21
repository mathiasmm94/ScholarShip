import Card from "@mui/material/Card";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";
import DeleteButtonReal from "./deletebutton";
import {NavLink} from "react-router-dom";
import './CSS/Annonce.css';

export function ProductCard({ Title, ImgSource, category, price, studieRetning, stand, id }) {
  return (
    <Card width="100%" variant={'elevation'} sx={{padding: '10px', margin: '10px'}} >
      <Stack justifyContent={"space-between"} alignItems={"center"} width={"100%"} spacing={10} direction={'row'}>
      <img alt="produktbillede" src={ImgSource} width={'150px'} />
        <Stack spacing={12} direction={'row'} sx={{justifyContent: 'space-between'}}>
        <div className="productCardDivTitel">Titel på bogen: <Typography fontWeight={'bold'}> {Title}</Typography></div>
        <div>Pris: <Typography fontWeight={'bold'}> {price} DKK.</Typography></div>
            <div>Kategori: <Typography fontWeight={'bold'}> {category}</Typography></div>
            <div>Studieretning: <Typography fontWeight={'bold'}> {studieRetning}</Typography></div>
            <div>Varens stand: <Typography fontWeight={'bold'}> {stand}</Typography></div>
        </Stack>
        <Stack minWidth={"150px"} spacing={2} direction={"column"}>
        <NavLink to={`/opdaterAnnonces/${id}`}>
          <button className="opdateAnnonceButton"> Opdater annonce</button>
        </NavLink>
        <DeleteButtonReal id={id}/>
        </Stack>
      </Stack>
    </Card>
  );
}
