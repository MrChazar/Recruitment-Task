import React, { useRef } from "react";
import  axios  from "axios";
import { useForm } from "react-hook-form";
import 'bootstrap/dist/css/bootstrap.min.css';

const DateForm = () => {
    const url = "https://localhost:7077";
    const form = useForm();
    const { register, control, handleSubmit, formState } = form;
    const { errors } = formState;
    
    const onSubmit = (data) => {
        const json = JSON.stringify(data);
        axios.post(url+"/CreateDateCalculation", {
            startDate: data.InitialDate,
            interval: parseInt(data.Interval),
            dayOfWeek: parseInt(data.DayOfTheWeek)
        })
            .then(response => {
                console.log(response)
                window.alert("Wysłano pomyślnie");
            })
            .catch(error => {
                console.error("Błąd Axios:", error);
                window.alert("Wystąpił błąd");
            });
    }

    return (
            <div className="container text-center">
                <h1>Formularz</h1>
                <form onSubmit={handleSubmit(onSubmit)} className="row justify-content-center">
                    <div className="col-md-12">
                        <label htmlFor="InitialDate" className="form-label">Data Początkowa</label>
                        <input
                            type="date"
                            id="InitialDate"
                            className="form-control"
                            {...register("InitialDate", {
                                validateCriteriaMode: "all",
                                required: {
                                    value: true,
                                    message: "Data jest wymagana."
                                },
                                validate: {
                                    isDate: value => {
                                        const today = new Date().toISOString().split("T")[0];
                                        return value <= today || "Data musi być wcześniejsza niż dzisiejsza.";
                                    }
                                }
                            })}
                        />
                    </div>
                    <div className="col-md-12">
                        <label htmlFor="Interval" className="form-label">Interwał</label>
                        <input 
                            type="number" 
                            id="Interval" 
                            className="form-control"
                            {...register("Interval", 
                            { 
                                validateCriteriaMode: "all",
                                required: {
                                    value: true,
                                    message: "Wartość Interwału jest wymagana."
                                },
                                validate: {
                                    isPositive: value => value > 0 || "Wartość musi być większa od zera."
                                }
                            })} 
                        />
                    </div>
                    <div className="col-md-12">
                        <label htmlFor="DayOfTheWeek" className="form-label">Dzień Tygodnia</label>
                        <select id="DayOfTheWeek" className="form-select" {...register("DayOfTheWeek", { required: true })}>
                            <option value="1">Poniedziałek</option>
                            <option value="2">Wtorek</option>
                            <option value="3">Środa</option>
                            <option value="4">Czwartek</option>
                            <option value="5">Piątek</option>
                            <option value="6">Sobota</option>
                            <option value="7">Niedziela</option>
                        </select>
                    </div>
                    <div className="col-12">
                        {Object.keys(errors).map((key, index) => (
                            <p key={index} className="text-danger">{errors[key].message}</p>
                        ))}
                        <button type="submit" className="btn btn-primary">Wyślij</button>
                    </div>
                </form>
            </div>
    );
  }
export default DateForm;