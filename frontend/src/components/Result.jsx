import React from 'react';
import axios from 'axios';
import { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const Result = () => {
    const url = "https://localhost:7077";
    const[result, setResult] = useState(null);
    const GetDate = () => {
        axios.get(url+"/GetLastDateCalculation")
            .then(response => {
                setResult(response.data);
                window.alert("Pobrano pomyślnie");
            })
            .catch(error => {
                console.error("Błąd Axios:", error);
                window.alert("Wystąpił błąd");
            });
    };

    return (
        <div className='text-center mt-1'>
            <button onClick={GetDate} className="btn btn-info">Wynik</button>
            {result !== null && (
                <div className='bg-dark text-white mt-1 rounded'>
                    <h1>Wynik</h1>
                    <ul className="list-group">
                        <li className="list-group-item bg-info">Ilość wystąpień: {result.numberofOccurences}</li>
                        <li className="list-group-item bg-info">Dzisiejsza data: {result.todayDate}</li>
                        <li className="list-group-item bg-info">Pierwsze wystąpienie: {result.firstAppearance}</li>
                        <li className="list-group-item bg-info">Poprzednie wystąpienie: {result.previousApperance}</li>
                        <li className="list-group-item bg-info">Następne wystąpienie: {result.nextApperance}</li>
                    </ul>
                </div>
            )}
            
        </div>
    );
};

export default Result;
