console.log("Yes it is being run");

$("#gradeButton").click(function() {
    console.log("Button Clicked");

    let HWMarg = $('#HWWeight').val() / 100;
    let PMarg = $('#PWeight').val() / 100;
    let QMarg = $('#QWeight').val() / 100;
    let TMarg = $('#TWeight').val() / 100;
    let MMarg = $('#MWeight').val() / 100;
    let FMarg = $('#FWeight').val() / 100;
    let OMarg = $('#OWeight').val() / 100;

    let HWscore = $('#HWscore').val() / 100;
    let Pscore = $('#Pscore').val() / 100;
    let Qscore = $('#Qscore').val() / 100;
    let Tscore = $('#Tscore').val() / 100;
    let Mscore = $('#Mscore').val() / 100;
    let Fscore = $('#Fscore').val() / 100;
    let Oscore = $('#Oscore').val() / 100;

    let HWGrade = HWMarg*HWscore*100;
    let PGrade = PMarg*Pscore*100;
    let QGrade = QMarg*Qscore*100;
    let TGrade = TMarg*Tscore*100;
    let MGrade = MMarg*Mscore*100;
    let FGrade = FMarg*Fscore*100;
    let OGrade = OMarg*Oscore*100;
    
    let finalGrade = HWGrade+PGrade+QGrade+TGrade+MGrade+FGrade+OGrade;

    let homework = $('#Homework');
    if((HWGrade/HWMarg) >= 0)
    homework.append('Homework: ' + (HWGrade/HWMarg).toFixed(2) + '%');

    let participation = $('#Participation');
    if((PGrade/PMarg) >= 0)
    participation.append('Participation: ' + (PGrade/PMarg).toFixed(2) + '%');

    let quizzes = $('#Quizzes');
    if((QGrade/QMarg) >= 0)
    quizzes.append('Quizzes: ' + (QGrade/QMarg).toFixed(2) + '%');

    let test = $('#Test');
    if((TGrade/TMarg) >= 0)
    test.append('Test: ' + (TGrade/TMarg).toFixed(2) + '%');

    let midterm = $('#Midterm');
    if((MGrade/MMarg) >= 0)
    midterm.append('Midterm: ' + (MGrade/MMarg).toFixed(2) + '%');

    let final = $('#Final');
    if((FGrade/FMarg) >= 0)
    final.append('Final: ' + (FGrade/FMarg).toFixed(2) + '%');

    let other = $('#Other');
    if((OGrade/OMarg) >= 0){
        other.append('Other: ' + (OGrade/OMarg).toFixed(2) + '%')
    }
    

    let grade = $('#output');
    grade.append('Final Grade: ' + (finalGrade).toFixed(2) + '%');

});

function refresh() {
    window.location.reload();
}