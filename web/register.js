function startPay(){
  document.getElementById("pay1").addEventListener('change', function() {
    let c = document.getElementById("pay1-ct").children;
    for (let i = 0; i < c.length; i++) {
      c[i].disabled = !pay1.checked;
    }
    document.getElementById("pay1-ct").style.display = pay1.checked ? "block" : "none";
  });
  document.getElementById("pay2").addEventListener('change', function() {
    let c = document.getElementById("pay2-ct").children;
    for (let i = 0; i < c.length; i++) {
      c[i].disabled = !pay2.checked;
    }
    document.getElementById("pay2-ct").style.display = pay2.checked ? "block" : "none";
  });
  document.getElementById("pay3").addEventListener('change', function() {
    let c = document.getElementById("pay3-ct").children;
    for (let i = 0; i < c.length; i++) {
      c[i].disabled = !pay3.checked;
    }
    document.getElementById("pay3-ct").style.display = pay3.checked ? "block" : "none";
  });
  document.getElementById("pay1").dispatchEvent('change');
  document.getElementById("pay2").dispatchEvent('change');
  document.getElementById("pay3").dispatchEvent('change');
}