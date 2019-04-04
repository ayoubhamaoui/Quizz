import React, { Component } from 'react';

export class Questions extends Component {
    static displayName = Questions.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, data:[] };
        
        console.log(this.state.data);
        fetch('api/Questions/Details/CSharp')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    static renderForecastsTable(forecasts) {
        return (
            <div>
            {forecasts.map(forecast =>
            <div className="row" key={forecast.idquestion}>
                <div className="col-sm-6">
                    <div className="card">
                        <div className="card-body">
                                    <h5 className="card-title">{forecast.question}</h5>
                            <div class="form-check">
                                        <input className="form-check-input" type="radio" name={forecast.question} id={forecast.idquestion} value={forecast.a}/>
                                    <label className="form-check-label" htmlFor="exampleRadios1">
                                            {forecast.a}
                                    </label>
                            </div>

                            <div className="form-check">
                                <input className="form-check-input" type="radio" name={forecast.question} id={forecast.idquestion} value={forecast.b}/>
                                    <label className="form-check-label" htmlFor="exampleRadios1">
                                            {forecast.b}
                                    </label>
                            </div>

                            <div className="form-check">
                                <input className="form-check-input" type="radio" name={forecast.question} id={forecast.idquestion} value={forecast.c}/>
                                    <label className="form-check-label" htmlFor="exampleRadios1">
                                            {forecast.c}
                                    </label>
                            </div>

                            <div className="form-check">
                                <input className="form-check-input" type="radio" name={forecast.question} id={forecast.idquestion} value={forecast.d}/>
                                    <label className="form-check-label" htmlFor="exampleRadios1">
                                            {forecast.d}
                                    </label>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                )}
            </div>
        );
    }

    render() {
        console.log(this.state.forecasts);
        let contents = <p><em>Loading...</em></p>
        let title="";
        if (this.state.loading === true) {

        } else {
            contents = Questions.renderForecastsTable(this.state.forecasts);
            title = this.state.forecasts[0].idQuizz;
        }

        return (
            <div>
                <h1>{title}</h1>
                {contents}
            </div>
        );
    }
}
