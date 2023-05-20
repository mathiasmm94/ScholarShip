import { ProductCard } from "./productCard";

export const ProfilePage = async () => {
    
    try {
        const response = await fetch("https://localhost:7181/api/Annonces", {
          method: "GET",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
         
          }),
        });
        console.log(response);
        if (!response.ok) {
          throw new Error("couldnt post ad");
        }
        alert('Annonce er tilføjet');
        const data = await response.json();
        console.log("data received:", data);
      } catch (error) {
        console.log("Error:  ", error);
      }

      

return (
    <>

        <label>Fisse</label>
        {data.map((d) => {<ProductCard Title={d.Title} ImgSource={d.ImgSource} />})}
        
    </>
)
}

