function reload
  #clusters = csvread('clusters.txt');
  #samples = csvread('samples.txt');
  actiontimes = csvread('actiontimes.txt');
  disp(actiontimes);
  figure;
#  set(gca, 'XTick', [0:2500:120000]);
#  set(gca, 'YTick', [-0.05:0.05:1]);
  hold on;
  #plot(samples, 'blue');
  #plot(clusters, 'red');
  hold off;
endfunction

