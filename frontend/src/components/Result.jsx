import React from 'react';

const Result = ({ result }) => {
    return (
        <div className='text-center'>
            <h1>Wynik</h1>
            <ul className="list-group">
                <li className="list-group-item">Ilość wystąpień: {result.numberOfAppearances}</li>
                <li className="list-group-item">Dzisiejsza data: {result.todayDate}</li>
                <li className="list-group-item">Pierwsze wystąpienie: {result.firstAppearance}</li>
                <li className="list-group-item">Poprzednie wystąpienie: {result.previousApperance}</li>
                <li className="list-group-item">Następne wystąpienie: {result.nextApperance}</li>
            </ul>
        </div>
    );
};

export default Result;
