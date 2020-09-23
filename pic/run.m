I = imread('3.bmp');
J = imfilter(I, fspecial('laplacian', 0.3));
J = im2bw(rgb2gray(J), 0.3);
%imshow(J);
[h, w] = size(J);
r = sqrt(h^2 + w^2) / 2.0 * 0.7;
%viscircles([h / 2.0, w / 2.0], r - 15);

%ÏûÈ¦
for i = 1 : h
    for j = 1 : w
        if (i - h / 2.0)^2 + (j - w / 2.0)^2 >= (r - 10)^2
            J(i, j) = 0;
        end
    end
end
imshow(J);

%É¨Ãè·¨
for i = h : -1 : 1
    %ÕÒ×ó
    for j1 = 1 : w
        if J(i, j1) > 0
            break
        end
    end
    %ÕÒÓÒ
    for j2 = w : -1 : 1
        if J(i, j2) > 0
            break
        end
    end
    %ÕÒµ½ÁË
    if j2 - j1 > 20
        break
    end
end
hold on;
plot([j1; w / 2.0], [i; h / 2.0], 'LineWidth', 4, 'Color', [.8 .1 .1]);
plot([j2; w / 2.0], [i; h / 2.0], 'LineWidth', 4, 'Color', [.8 .1 .1]);
