import react, { useState } from 'react'

export function CreateAnnonce() {
    const [price, setPrice] = useState(0);
    const [titel, setTitel] = useState('');
    const [kategori, setKategori] = useState('');
    const [beskrivelse, setBeskrivelse] = useState('');
    const [studieretning, setStudieretning] = useState('');
    const [billedsti, setBilledsti] = useState('');
    const [efManagerId, setEfManagerId]=useState('');
    const [stand, setStand]=useState('');
    const [chatId, setChatId]=useState('');

    const handleSubmit = () => {
        postAnnonce()
    };

    const postAnnonce = async () => {
        try {
            const response = await fetch('https://localhost:7181/api/Annonces', {
                method: 'POST',
                headers: {

                },
                body: JSON.stringify({
                    Price: price,
                    Titel: titel,
                    Kategori: kategori,
                    Beskrivelse: beskrivelse,
                    Studieretning: studieretning,
                    BilledSti: billedsti,
                    EfManagerId: efManagerId,
                    Stand: stand,
                    ChatId: chatId
                })
            });
            if (!response.ok) {
                throw new Error('couldnt post ad');
            };
            const data = await response.json();
            console.log('data received:', data);
        }
        catch (error) {
            console.log('Error:  ', error);
        }
    };



    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="price">Pris:</label>
            <input type="number" id="price" value={price} onChange={(e) => setPrice(e.target.value)} />

            <label htmlFor="title">Titel:</label>
            <input type="text" id="title" value={titel} onChange={(e) => setTitel(e.target.value)} />

            <label htmlFor="category">Kategori:</label>
            <input type="text" id="category" value={kategori} onChange={(e) => setKategori(e.target.value)} />

            <label htmlFor="description">Beskrivelse:</label>
            <textarea id="description" value={beskrivelse} onChange={(e) => setBeskrivelse(e.target.value)} />

            <label htmlFor="major">Studieretning:</label>
            <input type="text" id="major" value={studieretning} onChange={(e) => setStudieretning(e.target.value)} />

            <label htmlFor="image">Billedsti:</label>
            <input type="text" id="image" value={billedsti} onChange={(e) => setBilledsti(e.target.value)} />

            <label htmlFor="ManagerId">EfManagerId:</label>
            <input type="text" id="ManagerId" value={efManagerId} onChange={(e) => setEfManagerId(e.target.value)} />

            <label htmlFor="Condition">Stand:</label>
            <input type="text" id="Condition" value={stand} onChange={(e) => setStand(e.target.value)} />

            <label htmlFor="ChatId">ChatId:</label>
            <input type="text" id="ChatId" value={chatId} onChange={(e) => setChatId(e.target.value)} />

            <button type="submit">OPRET ANNONCE!</button>
        </form>
    )
}