import React, { Component } from 'react';

export class AddQuestion extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleSubmit(e) {
        e.preventDefault();
        const data = new FormData();

        data.append('a', this.a.value);
        data.append('answer', this.answer.value);
        data.append('b', this.b.value);
        data.append('c', this.c.value);
        data.append('d', this.d.value);
        data.append('idQuizz', this.idQuizz.value);
        data.append('idquestion', this.idquestion.value);
        data.append('poid', this.poid.value);
        data.append('question', this.question.value);
        console.log(data);
        fetch('api/question/create', {
            method: 'POST',
            body: data,
        }).then((response) => response.json())
            .then((responseJson) => {
                console.log("DONE!!");
            })
    }
    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <label htmlFor="a">a </label><br />
                    <input id="a" type="text" placeholder="Enter a" ref={(a) => this.a = a} />
                    <br /><br />
                    <label htmlFor="answer">answer: </label><br />
                    <input id="answer" type="text" placeholder="answer" ref={(answer) => this.answer = answer} />
                    <br /><br />
                    <label htmlFor="b">b: </label><br />
                    <input id="b" type="text" placeholder="b" ref={(b) => this.b = b} />
                    <br /><br />
                    <label htmlFor="c">c: </label><br />
                    <input id="c" type="text" placeholder="c" ref={(c) => this.c = c} />
                    <br /><br />
                    <label htmlFor="d">d: </label><br />
                    <input id="d" type="text" placeholder="d" ref={(d) => this.d =d} />
                    <br /><br />
                    <label htmlFor="idQuizz">idQuizz: </label><br />
                    <input id="idQuizz" type="text" placeholder="idQuizz" ref={(idQuizz) => this.idQuizz = idQuizz} />
                    <br /><br />
                    <label htmlFor="idquestion">Country: </label><br />
                    <input id="idquestion" type="text" placeholder="idquestion" ref={(idquestion) => this.idquestion = idquestion} />

                    <label htmlFor="poid">poid: </label><br />
                    <input id="poid" type="number" placeholder="poid" ref={(poid) => this.poid = poid} />
                    <br /><br />
                    <label htmlFor="question">question: </label><br />
                    <input id="question" type="text" placeholder="question" ref={(question) => this.question = question} />
                    <br /><br />
                    <p>
                        <button type="submit">Submit</button>
                    </p>
                </form>
            </div>
        );
    }
}
